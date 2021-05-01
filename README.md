## Update template

dotnet new -i .\

##
dotnet new apirestcrud -n myBestName --o c:\temp\


### `Up database local`

docker compose -f ./eng/docker/docker-compose.yaml up dbsqlserver -d

### `Create migration`
	` dotnet ef migrations add InitialCreate `

### `Sonar local`
docker compose -f ./eng/docker/docker-compose.yaml up sonarqube.postgresql sonarqube.portal -d

The page will reload if you make edits.\
You will also see any lint errors in the console.

### `npm test`

Launches the test runner in the interactive watch mode.\
See the section about [running tests](https://facebook.github.io/create-react-app/docs/running-tests) for more information.

### `npm run build`

Builds the app for production to the `build` folder. \dist
It correctly bundles React in production mode and optimizes the build for the best performance.

The build is minified and the filenames include the hashes.\
Your app is ready to be deployed!

for more information.

