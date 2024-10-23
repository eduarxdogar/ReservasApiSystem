# ClientApp. NET Core integration

## angular.json
The output was modified for exporting a production copy that Razor views can import in order to integrate Angular and NET Core.
```
"outputPath":"../wwwroot/dist"
```

## package.json
The node stored commands "build" and "watch" were modified and must be used from no on, when updating the frontend application. This way, NET Core can load and publish the changes.
```
npm run build
```
```
npm run watch
```
