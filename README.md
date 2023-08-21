# streamnesia-custompayload
This includes your own way to make payloads for your streamnesia without having to strictly play with the few possible payload sets.
----------------------------
Everything in the repository will be where your payload has been downloaded and is launching from, so put these in a new repository of your choice.

If you do not understand, check my payload set in my projects for further detail.
----------------------------
To put your payload set from github, go in src/Streamnesia-Payloads/LocalPayloadLoader once there, 

locate const string PayloadsUrl = "https://github.com/USERNAME/REPOSITORY/archive/main.zip"; and change as follows.
For me, its "https://github.com/rainforest39/streamnesia-payloads/archive/main.zip"

Once this is changed, make a folder in your amnesia directory called streamnesia and proceed to run the deploy ps1 file with Powershell. Once completed, proceed in Amnesia The Dark Descent\streamnesia and you will find your final product. https://github.com/petrspelos/Streamnesia/wiki/setup some of the instructions by the original creator. Once all is completed, proceed in OBS to make a browser and put as in URL: http://localhost:5000 and put the size as 1920x1080.
