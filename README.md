# VirtualRealty Vertical Prototype
## Full Names
Oscar Wong

Chris Kozbial

Mathew Luong

Antonio Santos

Diego Munoz

## Instructions
*Note: these instructions were developed using Visual Studio 2019 with .NET Core 3.0*
1. Open VirtualRealty.sln in Visual Studio
2. Press the green Play button, labeled VirtualRealty, to start the app.
3. Enter a location in the location input, and click the search icon OR press enter while the input is focused to search.
    * Location search is a basic string match, and all of our listings are in Calgary. So, "calgary" or "calgar" will turn up results, "edmonton" will not.
4. Select any of the other filters and search as you would expect.
    * Caveats: 
      * Price can only handle numeric characters and commas, and will attempt to parse commas into thousands (like 100,000). Incorrect formatting will crash the app.
      * Year built will not return any results if your max year build is < your min year built.
5. Feel free to sort the listings as you see fit.
6. When you switch to the map view, there is a chance the markers will not load. We think this is a race condition of some sort. If this happens, click the VirtualRealty logo on the top left to reset the search results pages and try again.
7. Only three listings (the first two sorted by new under Purchase, and the first one when sorted by price low to high also under Purchase) have "complete" images. The other listings just copy their non-thumbnail images from these.
    * This is hardcoded to those listings, not the order/sorting.
8. The Map inside of a listing popup is just an image.
9. Saved Searches works as intended, but the top bar after searching will not reflect the search. Changing the top bar filters will overwrite the search to what is on the top bar (so, you will go from a very filtered search to one with just one filter applied)
10. Favourites is very similar to the search results view which you should be familiar with by now.