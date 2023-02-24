//import required modules
const express = require("express");
const path = require("path");
const dotenv = require("dotenv");

dotenv.config();


const trakt = require("./modules/trakt/api");

//set up Express app
const app = express();
const port = process.env.PORT || 8888;

//define important folders
app.set("views", path.join(__dirname, "views"));
app.set("view engine", "pug");
//setup public folder
app.use(express.static(path.join(__dirname, "public")));

//PAGE ROUTES
app.get("/", async (request, response) => {
  let moviesList = await trakt.getTrendingMovies();
  //console.log(moviesList);
  response.render("index", { title: "Movies", movies: moviesList });
});
app.get("/movie-info", async (request, response) => {
  let rating = await trakt.getMovieRating(request.query.id);
  response.render("movie", { title: "About movie", rating: rating });
});

app.get("/popular-show", async (request, response) => {
let showPopular = await trakt.getPopularShows();
console.log(showPopular);
response.render("shows", {title: "Popular shows", showPopular: showPopular})
});

//set up server listening
app.listen(port, () => {
  console.log(`Listening on http://localhost:${port}`);
});


