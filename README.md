> This is a fork of the sample app provided by SKTST for the Danish Moms api.  
> I have extended it to support making calls to all three of the webservices that are availalbe in the API. 
> Added a "testvalues.json" file to store the values that are used in the calls to the API."
> Added a menu in the console app to select which service to call and to input the values for the call.
> The original sample app can be found [here](https://github.com/skat/rsu-b2b-sample-client-dotnet).
> The below info is from the original readme.

# RSU B2B Sample Client - .NET Core Sample

> **IMPORTANT NOTICE**: UFST does not provide any kind of support for the code in this repository.
> This client is just one example of how a B2B web service can be accessed. The client must not be 
> perceived as a piece of production code but more as an example one can take inspiration from and can use
> to quickly get started to test whether your company can implement a successful call to one of the B2B web 
> service using the company's digital signature. UFST can not be held responsible if a company uses this client
> or parts of it in their own systems. 

> **VIGTIG MEDDELELSE**: UFST yder ikke support på kildekoden i nærværende kodebibliotek.
> Denne klient er kun et eksempel på hvordan B2B webservicene kan tilgås. Klienten skal således ikke 
> opfattes som et stykke produktionskode men mere som en eksempel man kan lade sig inspirere af og kan bruge 
> til hurtigt at komme i gang og få afprøvet om ens virksomhed kan gennemføre et succesfuldt kald til en af 
> B2B webservicene ved at bruge virksomhedens digitale signatur. UFST kan ikke stå til ansvar hvis en virksomhed
> anvender klienten eller dele af denne i deres egne systemer. 


## Build and run

First build:

```
$ dotnet build
```

Then overwrite contents of

```
$ appsettings.json
```

with the contents of `appsettings-secret.json` provided to you by UFST.

Update the contents of 
```
$ testvalues.json
```
These will be used when the app is run and can be changed whilst the app is running for easier testing.

Finally, run application, e.g.:

```
$ dotnet run 
```

key in a number to call the selected service with values from testvalues.json

## View certificates

Print `server.pem`:

```
$ openssl x509 -in server.pem -text
```