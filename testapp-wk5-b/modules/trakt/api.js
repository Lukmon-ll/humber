const trakt = "https://api.trakt.tv"; //base URL for any Trakt API requests

/*
 * Functions for Trakt API requests.
 */
async function getTrendingMovies() {
  let reqUrl = `${trakt}/movies/trending`;
  let response = await fetch(
    reqUrl,
    {
      method: "GET",
      headers: {
        "Content-Type": "application/json",
        "trakt-api-version": "2",
        "trakt-api-key": process.env.TRAKT_CLIENT_ID
      }
    }
  );
  return await response.json();
}

async function getMovieRating(imdbId) {
  let reqUrl = `${trakt}/movies/${imdbId}/ratings`;
  //For POST requests, if you need to pass data, you need to pass
  //it using the following option:
  //* body: <data_to_pass>
  let response = await fetch(
    reqUrl,
    {
      method: "GET",
      headers: {
        "Content-Type": "application/json",
        "trakt-api-version": "2",
        "trakt-api-key": process.env.TRAKT_CLIENT_ID
      }
    }
  );
  return await response.json();
}

//function to get the popular shows
async function getPopularShows() {

  let reqUrl = `${trakt}/shows/popular?page=1&limit=15`;
  let response = await fetch(

    reqUrl,
    {
      method: "GET",
      headers: {
        "Content-Type": "application/json",
        "trakt-api-version": "2",
        "X-Pagination-Page": "1",
        "X-Pagination-Limit": "15",
        "X-Pagination-Page-Count": "2",
        "X-Pagination-Item-Count": "30",
        "trakt-api-key": process.env.TRAKT_CLIENT_ID
      }

    }
  );

  return response.json();
}

module.exports = {
  getTrendingMovies,
  getMovieRating,
  getPopularShows
};