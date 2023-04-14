//Import required modules
const express = require("express");
const path = require("path");
const dotenv = require("dotenv");

dotenv.config();

const owm = require("./module/owm/api");
const google = require("./module/google/api");


//Set up express app and port 
const app = express();
const port = process.env.PORT || 8888;

//Set up static file path
app.use(express.static(path.join(__dirname, "public")));

//Set up template engine and view
app.set("views", path.join(__dirname, "views"));
app.set("view engine", "pug");

const parksArr = [
  {
    name: "Aaron",
    lat: 49.758123,
    long: -92.653490
  },
  {
    name: "Arrow Lake",
    lat: 48.17012017,
    long:-90.22694426
  },
  {
    name: "Arrowhead",
    lat: 45.3915,
    long:-79.2140
  },
  {
    name: "Algonquin",
    lat: 45.442046,
    long: -78.820583
  },
  {
    name: "Awenda",
    lat: 44.843699,
    long: -80.002699
  },
  {
    name: "Balsam Lake",
    lat: 44.62555,
    long: -78.85738
  },
  {
    name: "Bass Lake",
    lat: 44.601000,
    long: -79.482900
  },
  {
    name: "Batchawana Bay",
    lat: 46.944168,
    long: -84.551017
  },
  {
    name: "Biscotasi Lake",
    lat: 47.352455,
    long: -81.997528
  },
  {
    name: "Blue Lake",
    lat: 49.904122,
    long: -93.469178
  },
  {
    name: "Bon Echo",
    lat: 44.89720,
    long: -77.20950
  },
  {
    name: "Bonnechere",
    lat: 45.65729,
    long: -77.57886
  },
  {
    name: "Bronte Creek",
    lat: 43.40684,
    long: -79.76889
  },
  {
    name: "Caliper Lake",
    lat: 49.068974,
    long: -93.904116
  },
  {
    name: "Charleston Lake",
    lat: 44.50176,
    long: -76.04133
  },
  {
    name: "Chutes",
    lat: 46.217628,
    long: -82.070231
  },
  {
    name: "Craigleith",
    lat: 44.53622,
    long: -80.34897
  },
  {
    name: "Darlington",
    lat: 43.8755,
    long: -78.777834
  },
  {
    name: "Driftwood",
    lat: 46.18000,
    long: -77.84000
  }
  
];


//Page route
app.get("/", async(request, response) => {
  //response.status(200).send("Test");
  
  let theweather = await owm.openweathermap(45.442046, -78.820583);
  //console.log(theweather);
  response.render("index", { title: "Home page", parks: parksArr, weather: theweather });
});

app.get("/weather", async(request, response) => {
  console.log(request.query.id1);
  const path = request.query.id1;
  const splitPath = path.split("?");
  const x = splitPath[0];
  const y = splitPath[1].split("=")[1];
  
//console.log(x);
//console.log(y);

  let weather = await owm.openweathermap(x, y);
  //console.log(weather);
  let map = await google.googlestaticmaps(x, y);
  
  console.log(map);

  response.render("weather", { title: "park description", weather: weather, map: map});
});

//Page to get the weather of specific park
/*app.get("/Gatehouse", async(request, response) => {
  let weather = await owm.openweathermap(parksArr[0].lat, parksArr[0].long);
  console.log(weather);
  response.render("Gatehouse", {title: "Gatehouse", weather: weather });
})*/

//Set up server listening
app.listen(port, () => {
  console.log(`Listening on http://localhost:${port}`);
});


