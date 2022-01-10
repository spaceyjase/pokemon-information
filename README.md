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

### That's all, have fun!
