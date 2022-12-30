# KeyAuthServerEmulator

With this LocalHost Server (C#), you can emulate almost every features from KeyAuth Original Client. 

# How it works

- First of all, it will intercepts KeyAuth.Win Requests from a Program.

- After, it bruteforces the Secret through a list of Strings provided by the user (if you already know the secret, you can use it, without using the bruteforcer).

- Once you have obtained the secret, it will decrypt the EncKey, stored in the Init Request.

- The emulator will send positive response for each request it receives. Some API Features, like fetchOnlineUser or KeyAuthDownload, are not supported.

**Info about Application Secret:**

- Application Secret is a 64-Length String. You can grab it from Process Hacker 2, and after bruteforce it. 

- Obfuscators like VMProtect 3.6.0 (Max settings. Virtualization enabled) or .NET Reactor 6.9.0 (Max settings. Virtualization enabled) can not stop this process, or hide the Secret.

**IS THAT A BYPASS?**

Absolutely NO. This program **IS NOT** a KeyAuth Bypass, as its purpose is only to emulate the KeyAuth Server, and this can be done by every program, or even manually!

So please, do not call my Emulator, a "Bypass", because you would spread false informations.

# ShowCase

![emulator](https://user-images.githubusercontent.com/92642446/210102458-27a0d288-02a8-4275-8d64-2c987c2a5175.png)

Init and Check requests intercepted and tampered by my LocalHost Server.

# Emulator Release

Source Code released on 30/12/2022.

# Contact Me

Do you want to contact me? 

Discord: FreeCabbo11#9191 - Use Telegram, I get banned very often.

Telegram: https://t.me/cabboshiba

# License 

Repostory and Bypass under License GNU General Public License, version 3 (GPLv3).

You are not allowed to resell the program, or the source sode.

Please, if you want to Re-Create this project or this idea, give me credit:
 
https://github.com/CabboShiba

Made by Cabbo on 21-08-2022.


