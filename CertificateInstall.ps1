dotnet dev-certs https -ep $env:USERPROFILE\.aspnet\https\Products.API.pfx -p 100Rage69
dotnet dev-certs https --trust
cd Products.API
dotnet user-secrets set "Kestrel:Certificates:Development:Password" "100Rage69"
cd ../