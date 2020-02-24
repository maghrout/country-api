# Countries API

## .NET CORE 2.x MVC

This is an API which allows you to pass in an ISO country code and returns a structured JSON response

### For example:

A request for Algeria with the ISO Code DZ:

```
https://localhost:44304/country/DZ
```

JSON response:

```json
{
    "country" : "Algeria",
    "httpStatusCode" : 200
}
```

Codes that are passed in can be either uppercase or lowercase but must be trimmed.

It reads it's data from disk and you can find the path in `appsettings.json` in the following format:

```json
  "CountryDataFilePath": "./Data/countries.json" 
```

The format of the JSON file is as follows:

```json
{
    "AF": "Afghanistan",
    "AX": "\u00c5land Islands",
    "AL": "Albania",
}
```

## Statuses

* 200: Valid response with country returned
* 404: Country not found
* 503: Service unable to load countries

## Performance

In order to improve performance, the country repository only loads the country list once and on startup for the application to continue to use.
