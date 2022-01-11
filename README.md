# Pokemon Information

A small engineering challenge.

### Running the API in a container:

1. Download or clone the respoitory to a local folder.
2. Open a terminal in the folder location.
3. Enter the following to build a container:

        $ docker build -t pokemon-information .
  
4. Run the container:

        $ docker run -d -p 8080:80 --name app pokemon-information

5. Test the endpoint, e.g.

        $ http http://localhost:8080/pokemon/mewtwo
        $ http http://localhost:8080/pokemon/translated/ditto
        
### Running in a terminal

1. Download or clone the respoitory to a local folder.
2. Open a terminal in the folder location.
3. Enter:

        dotnet build --configuration Release
        
4. To run with the default configuration:

        dotnet .\pokemon-information\bin\Release\net5.0\pokemon-information.dll
        
5. Test using a browser (or your favourite `curl` utility):

        https://localhost:5001/pokemon/mewtwo
        
### Production considerations:

- Authentication - e.g. to ensure only certain clients can use certain endpoints/features, API keys for third-party calls.
- Security, such as HTTPS, XSS and headers. Supressing verbose error messages.
- Model binding on Get requests for validation e.g. `Get(PokemonName name); // model should validate before it hits the controller`
- Resilience and stability; target platform(s) may affect deployment targets.
- Teamwork and communication - on going feedback, fresh pair of eyes, code review.
- CI actions, CD, code coverage and static analysis.

### That's all, have fun!
