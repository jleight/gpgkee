GpgKee
======

GpgKee is a KeePass plugin that provides GPG authentication.


WARNING
-------

The GpgKee plugin is EXTREMELY basic. There is no guarantee that it will work
for you. There is no error handling. There are no tests of any sort. Do not use
this plugin unless you are willing to lose everything in your KeePass database.


About
-----

GpgKee can be used as a secondary component to your KeePass master key. It uses
the GPG application on your computer to decrypt an encrypted secret key. If it
is able to decrypt the key, the key is passed along to KeePass to decrypt your
password database.

GpgKee is currently very minimal. There are no GUI components to help you
generate your encrypted secret key and there is no error handling. These
components should be added eventually, but the plugin works in its current
state.


Usage
-----

GpgKee currently has two requirements:

1. You must have [Gpg4win](http://www.gpg4win.org/) installed to the default
  location. GpgKee is hard coded to use the `gpg2` executable located at
  `C:\Program Files (x86)\GNU\GnuPG\pub\gpg2.exe`.
2. Your pinentry must open in a new window so that when GpgKee executes the
  `gpg2` application, the pinentry application can prompt you for your password.

### Generate GpgKee File

Once you have Gpg4win installed and configured, you need to generate a secret
key. You can use anything you want as the secret key.

Once you have a secret key, encrypt it with GPG:

```cmd
gpg2 --output secret-key.gpg --encrypt --recipient *your public key* secret.key
```

Once you have your encrypted secret key, move it to the same folder as your
KeePass kbdx file and rename it the same name as your KeePass database with a
".gpgkee" extension.

For example, if your KeePass database is called "Personal.kbdx", name your
gpg encrypted secret key "Personal.gpgkee".

### Change Master Key

Now that your secret key is set up, you can change your master key to use the
GpgKee secret key.

1. Open your KeePass database.
2. Click File >> Change Master Key...
3. Check the "Key file / provider" checkbox.
4. Select the "GPG Authentication" provider.
5. Click OK.
6. Type in your GPG key pin if you are prompted.
7. Save your database.

If all went according to plan, when you open your database again, you will be
prompted for your GPG key pin and your password database will open.
