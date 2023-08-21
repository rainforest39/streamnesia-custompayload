# streamnesia-custompayload
This includes your own way to make payloads for your streamnesia without having strictly 3 possible payload sets to play with.
----------------------------
Everything in the repository will be where your payloads will download and launch from, so put these in a new repository of your choice. 

If you do not understand, check my payload set in my projects for what I mean.
----------------------------
To put your payload set from github, go in src/Streamnesia-Payloads/LocalPayloadLoader once there, 

locate const string PayloadsUrl = "https://github.com/USERNAME/REPOSITORY/archive/main.zip"; and change as follows.


for me it would be const string PayloadsUrl = "https://github.com/rainforest39/streamnesia-payloads/archive/main.zip";
