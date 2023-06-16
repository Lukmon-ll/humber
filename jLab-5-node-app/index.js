//require modules
const express = require("express");
const path = require("path");

//set up express app and port
const app = express();
const port = process.env.PORT || 8888;

//set up static file path
app.use(express.static(path.join(__dirname), "public"));


//set up template engine
app.set("views", path.join(__dirname, "views"));
app.set("view engine", "pug");




