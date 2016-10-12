VF-CryptoNote-Miner
===
Based on [CryptoNote-Easy-Miner](//github.com/zone117x/cryptonote-easy-miner)
===

Currently only 64 bit

This is a simple C# app that helps Windows users start mining without dealing with command-line operated binaries. It is bundled with the latest 64 bit builds of cpuminer, ccminer, Claymore's CryptoNote GPU Miner, and simplewallet to provide as many ways to mine as possible.


Upon starting for the first time it will run simplewallet to generate a new address (with a default wallet password of `x`). The user can then input a pool host & port, select how many CPU cores they want to use, the click `Start Mining`.

If you do not want to generate a new address for your miner, just place your current wallet's infomation into the directory, then open the miner.
![ss](https://i.gyazo.com/5fa65214bebc5111993f82e6e9a10bb2.png)

The app will spawn instances of cpuminer for each core and the chosen gpu miner with the appropriate command-line arguments.

###To-Do
Add hashrate viewer

####Download

Get the latest build here: [releases](//github.com/UsernameVF/vf-cryptonote-miner/releases)



43hz7w1GHdxcPab7BwE2pGezmhXPFaqLxZBcmVgvWzvMN4EhkbifYHE5fhsUHqAZDLMEdgbDmsNTXfVxEUwzzuBNASmt9FW
