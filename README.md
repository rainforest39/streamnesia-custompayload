# streamnesia-custompayload
This includes your own way to make payloads for your streamnesia without having to strictly play with the few possible payload sets.
----------------------------
Everything in the repository will be where your payloads will download and launch from, so put these in a new repository of your choice. 

If you do not understand, check my payload set in my projects for what I mean.
----------------------------
To put your payload set from github, go in src/Streamnesia-Payloads/LocalPayloadLoader once there, 

locate const string PayloadsUrl = "https://github.com/USERNAME/REPOSITORY/archive/main.zip"; and change as follows.
For me, its "https://github.com/rainforest39/streamnesia-payloads/archive/main.zip"

Once this is changed, make a folder in your amnesia directory called streamnesia and proceed to run the deploy ps1 file with Powershell. Once completed, proceed in Amnesia The Dark Descent\streamnesia and you will find your final product.
