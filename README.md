# KeyAuthServerEmulator - DROP STAR AND FOLLOW TO SUPPORT ME

NOTE: This program got patched on 27/01/2023 by Keyauth Dev Team. 

~~I'm currently working on a new emulator, but I will not probably release it.~~
 
 Done. I will not release it.

I think this project is a good start, and you could update it yourself. 

Hope you enjoyed it. 

**THIS IS NOT A BYPASS!**

With this LocalHost Server (C#), you can emulate almost every features from https://KeyAuth.Win Original Server. It uses API V1.0.

Tested with C# example, I dont know if it works also for other languages (It should work also with C++ but I'm not sure).

There are features that may not work (like Variables). I have not tested them for a long time.

**I wrote this code months ago, and it is not perfect. It can be greatly optimized, but due to lack of time/interest I will not do it.**

**I need help for some functions, so if you are interested in the project and you want to collaborate, do not hesitate to contact me.**

# Skids

**Please, do not try in ANY way and under ANY circumstances to sell it. If you get caught selling it, I will immediately release a patch for it, and it will become useless.**

Enjoy it while you can.

# How it works

- First of all, it intercepts HTTP requests from https://KeyAuth.Win/api/1.0 .

- After, it bruteforces the Secret through a list of Strings provided by the user (if you already know the secret, you can use it, without using the bruteforcer).

- Once you have obtained the secret, it will decrypt the EncKey, stored in the Init Request.

- The emulator will send positive response for each request it receives. Some API Features, like fetchOnlineUser or KeyAuthDownload, are not supported.

# How can I use it?

- Download Fiddler [Here](https://www.telerik.com/download/fiddler/).
- Install the Certificate to decrypt SSL.
- Create a new rule like this: 

![image](https://user-images.githubusercontent.com/92642446/210103619-184aee63-0e0f-49ac-b866-917f7de17704.png)

- Check "Unmatched requests passthrough" and "Enable Rules"
- Run your Application.
- Open Process Hacker and grab strings from memory with this params:

![image](https://user-images.githubusercontent.com/92642446/210103715-9f031a40-b9fa-4ac2-aebe-0c7da08dded7.png)

- Save the strings in the ServerEmulator with the name Strings.txt
- Start the Emulator, and after your Program.

**Info about Application Secret:**

- Application Secret is a 64-Length String. You can grab it from Process Hacker 2, and after bruteforce it. 

- Obfuscators like VMProtect 3.6.0 (Max settings. Virtualization enabled) or .NET Reactor 6.9.0 (Max settings. Virtualization enabled) can not stop this process, or hide the Secret.

**IS THAT A BYPASS?**

Absolutely NO. This program **IS NOT** a KeyAuth Bypass, as its purpose is only to emulate the KeyAuth Server, and this can be done by every program, or even manually!

So please, do not call my Emulator, a "Bypass", because you would spread false informations.

It is not KeyAuth's fault. They provide a great licensing system.

**THIS IS NOT THE SAME EMULATION AS KEYAUTH "BYPASSES". THE TERM EMULATION HERE REFERS TO "EMULATING" A PUBLIC SERVER BY USING THE SAME KEYAUTH APPLICATION INFORMATION TO MAKE THIS TOOL LOOKS LIKE THE SERVER. IT DOES NOT INTERACT WITH THE PROGRAM'S MEMORY IN ANY WAY.**

[DMCA](https://github.com/CabboShiba/KeyAuth-Server-Emulator/blob/main/README.md#dmca-violations)

# ShowCase

Emulator:

![emulator](https://user-images.githubusercontent.com/92642446/210102458-27a0d288-02a8-4275-8d64-2c987c2a5175.png)

Init and Check requests intercepted and tampered by my LocalHost Server.

Client:

![client](https://user-images.githubusercontent.com/92642446/210105038-43e141db-1649-47ac-9c0e-6c16d54c190a.jpg)

# Emulator Release

Source Code released on 30/12/2022.

I have decided to release it, because in the past months I've seen tons of skids asking for stupid help with KeyAuth. 

All these "devs" have literally 0 knowledge about coding, or security. They are trying to sell their pasted cheats and make money, without even knowing basic programming skills.

That's why I have decided to release it. I am 100% sure this project will not harm skilled developers, as they will be able to fix and patch it. I have many other methods, but for now I'll keep them private.

# Contact Me

Do you want to contact me? 

Discord: FreeCabbo11#9191 - Use Telegram, I get banned very often.

If you do not get an answer on Discord for 48 Hours, this means I got banned. Contact me on Telegram.

Telegram: https://t.me/cabboshiba

# License 

The Repository and the Project are under License GNU General Public License, version 3 (GPLv3).

You are not allowed to resell the program, or the source sode.

Please, if you want to Re-Create this project or this idea, give me credit:
 
https://github.com/CabboShiba

Made by Cabbo on 21-08-2022.

# Donations

This project will probably get patched in some days/weeks. I'll do my best to do a new 0Day.

If you can, I'd really appreciate some donations:

- BTC: *bc1q0x2jne24kyg8jhcuns9xdd7smwxqwknzz0qn4g*
- ETH: *0xF1bfba01160281Ec1bB11c9adBf36C9fc2478A1F*
- LTC: *LgwW18eQpYJywWxz1vb8JkFtyhX2ezEag7*
- SOL: *FVhWczmtvRd7oxdEpZqKBqUHABR6wkihXpAJmcsJhsPw*
- USDC on ETH NetWork: *0xF1bfba01160281Ec1bB11c9adBf36C9fc2478A1F*
- MONERO: *49K92AFva9EabaMezpEqko7MzJLbkRfMq8Uki6WcMjV6Vn6AH8dcPGoFPQ1N2mpSnmLQ6Mw1MNinoAbbQz46eLhj9XnJepE*
- BTC Cash: *qqqvfqsls7tdrpktq6kax2sudl4zeg828uhrvev92a*
- BNB on BNB NetWork: *bnb1vf25nj8y6sft8ykflhd7rkwkewramxm3qczfh2*
- XRP: *raGi2w3mYMAaajLrFTXbhwE6BSRDxvYz1n*
- DOGE: *DPAC6a1wAPaMgF2uogSrXqEGNkzi5hdJ19*
- DOT: *12Jk63p5rWxPfHXZQgoUcat48uYVcAhNxiykCZ51LYB7cBK1*
- NANO: *nano_34uibzchxh6a6di6ayhwoaekh678bsscb7hcgepqrhgs7ay4csp8kfz4xjke*
- CRO on ETH NetWork: *0xF1bfba01160281Ec1bB11c9adBf36C9fc2478A1F*

# DMCA VIOLATIONS

Does this projects violates DMCA? Absolutely not.

**This program only show a method that can be done manually without any problem. It is basically a clone of the original KeyAuth Server. This can be done by everyone, and it does not interact with Process Memory.**

**It does not modify programs in any way.**
