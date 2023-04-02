import { useState, useEffect } from "react";

export default function() {
  const [category, setcategory] = useState(null);
  const [question, setquestion] = useState(null);
  const [answer, setanswer] = useState(null);
  const [revealed, setrevealed] = useState("false");

  useEffect(() => {
    const getAPI = async() => {
      let response = await fetch(
        "https://opentdb.com/api.php?amount=1&category=18&difficulty=medium&type=boolean"
      );

      let data = await response.json();
      {/*console.log(data.results["0"].category);*/}
      setcategory(data.results["0"].category);
      setquestion(data.results["0"].question);
      setanswer(data.results["0"].correct_answer);
      
    }
    getAPI();
  }, []);

  let Answer = "";

  if(revealed === "false") {
  Answer = <div></div>;
  } else if (revealed === "true") {
    Answer = <div>{answer}</div>
  }

  const handler = () => {
    setrevealed("true");
  }
  

  return(

    <div>
      <div>{category}</div>
      <h3>{question}</h3>
      <div>{Answer}</div>
      <button onClick={handler}>Reveal Answer</button>
    </div>
  );
}