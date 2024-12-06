{
  # NOTE: Lines starting with `#` are commented out!
  description = "A flake for dotnet development.";
 
  inputs = {
    nixpkgs.url = "github:NixOS/nixpkgs/nixos-unstable";
    flake-utils.url = "github:numtide/flake-utils";
  };

  # Flake outputs
  outputs = { self, nixpkgs, flake-utils }:


    let
      # The systems supported for this flake
      supportedSystems = [
        "x86_64-linux" # 64-bit Intel/AMD Linux
        "aarch64-linux" # 64-bit ARM Linux
        "x86_64-darwin" # 64-bit Intel macOS
        "aarch64-darwin" # 64-bit ARM macOS
      ];

      # This is a helper function to provide system-specific attributes
      # 1. It takes a funciton `f` as its input parameter.
      # 2. It uses `nixpkgs.lib.genAttrs` utlity funciton from the nix standard \ 
      #    library to generate attributes for each system
      #    in the `supportedSystems` array defined above.
      # 3. For each system, it calls the provided function `f` with an argument \
      #    containing `pkgs` initialized for that specific system
      # NOTE: the function `f` is actually defined and passed in when `forEachSupportedSystem` is invoked below.
      forEachSupportedSystem = f: nixpkgs.lib.genAttrs supportedSystems (system: f {
        pkgs = import nixpkgs { inherit system; };
      });
    in
    {
      devShells = forEachSupportedSystem ({ pkgs }: 
        let
          # Things i need at build time
          nativeBuildInputs = with pkgs; [];

          # Things i need at runtime
          buildInputs = with pkgs; [];

          # Define your package list once
          myPackages = with pkgs; [
            # common build inputs
            #direnv
            xclip
            duf
            eza
            fd

            # project-specific build inputs go here
            # rustup
            # sqlite
            # openssl
            # pkg-config
            # tailwindcss
            dotnetCorePackages.sdk_9_0

            # {{{ Add these as needed

              ## NOTE: If you are building graphical applications, 
              # you will likely need wayland support from the below dependencies!
               
              #cmake
              #pkg-config
              #fontconfig
              #libxkbcommon
              #libGL

              ## WINIT_UNIX_BACKEND=wayland
              #wayland
              
              ## WINIT_UNIX_BACKEND=x11
              #xorg.libXcursor
              #xorg.libXrandr
              #xorg.libXi
              #xorg.libX11

              ## contains gcc compiler, among other things
              #libgccjit

            # }}}

            # for fun
            cowsay
            lolcat
          ];
        in {
          default = pkgs.mkShell {

            # The Nix packages provided in the environment
            # Add any additional packages needed to the myPackages array above.
            packages = myPackages;

            # Set any environment variables for your dev shell
            env = {
              GREETING = "Welcome to your Dotnet environment!";

              # Add DOTNET_ROOT environment variable
              # NOTE: Need to use the `.passthru.unwrapped` attribute to get at \
              #       the actual sdk install path (avoid the `wrapped` path)
              # NOTE: Check that the $DOTNET_ROOT variable matches the sdk \
              #       install path with `dotnet --info` after environment is launched
              DOTNET_ROOT = "${pkgs.dotnetCorePackages.sdk_9_0.passthru.unwrapped}/share/dotnet";

              # Ensure .NET SDK is in PATH
              # NOTE: Need to use the `.passthru.unwrapped` attribute to get at \
              #       the actual sdk install path (avoid the `wrapped` path)
              PATH = "${pkgs.dotnetCorePackages.sdk_9_0.passthru.unwrapped}/share/dotnet/sdk/9.0.100/bin:$PATH";

              # NOTE: This was usefull to see the attributes available to the \
              # dotnetCorePackages nix package!
              # DEBUG_PASSTHRU = builtins.toJSON pkgs.dotnetCorePackages.sdk_9_0.passthru;

              # Make sure all libraries are added to the PATH
              LD_LIBRARY_PATH = pkgs.lib.makeLibraryPath myPackages;
            };

            # Add any shell logic you want executed any time the environment is activated
            shellHook = ''

              # echo "Passthru debug: $DEBUG_PASSTHRU" > passthru.txt

              # Welcome message for shell
              echo $GREETING | cowsay | lolcat

              #alias ls=eza
              #alias ls="ls -alh --color=auto"
              alias ls="eza --long --group --header -a --classify --links --level=3 --color=auto --sort=type --time-style=long-iso --extended"
              alias find=fd
              alias fd="fd --hidden --list-details --color=auto" # cannot be aliased to 'find' if using hlissner doom emacs
              #alias fd="fd --hidden --no-ignore --follow --list-details --color=auto" # cannot be aliased to 'find' if using hlissner doom emacs
              #alias fd="find -L" # cannot be aliased if using hlissner doom emacs
              alias du="duf"

              #git
              alias gst="git status"
              alias gc="git commit"
              alias gcm="git commit -m"
              alias ga="git add"
              alias gaa="git add --all"
              alias gcl="git clone -v --progress"
              alias gb="git branch"
              alias gp="git push -u"
              alias gpu="git push -u"

              #import parent shell config
              [ -x ~/.bashrc ] && source ~/.bashrc
              [ -x ~/.zshrc ] && source ~/.zshrc
            '';
          };
        });
    };
}
