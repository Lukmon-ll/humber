//Import the required modules
const express = require("express");
const path = require("path");

//Set up an express app and port number
const app = express();
const port = process.env.PORT || 8888;

//Set up template engine
app.set("views", path.join(__dirname, "views"));
app.set("view engine", "pug");

//Set up static files
app.use(express.static(path.join(__dirname, "public")));

//Page routes
app.get("/", (request, response) => {
//response.status(200).send("Testing lokolass store the second time and the fouth time and the sixth time the 7th time");
//response.render("layout", {title: "layout template"});
response.render("index", {title: "Home"});
});

//Set up server listening
app.listen(port, () => {
  console.log(`Listening on http://localhost:${port}`);
});