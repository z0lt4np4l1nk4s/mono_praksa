import React from 'react'
import joker from '../files/joker.jpg'
import CustomFunctionButton from './CustomFunctionButton';

export default function JokeButton() {

    function getJoke()
    {
        fetch('https://v2.jokeapi.dev/joke/Programming?blacklistFlags=nsfw,sexist&type=single')
        .then(async response => {
            let result = await response.json();
            document.getElementById('jokeDiv').innerHTML = '<h4 class="text-light"><strong>' + (result['joke'] ?? '') + '</strong></h4>';
        });
        
    }

  return (
    <div className='bg-secondary'>
        <h3 className='text-light'>Hi, I am your joke master for the day!</h3>
        <br></br>
        <CustomFunctionButton buttonColor='light' onClick={(e) => getJoke()}><img src={joker} alt="joker" style={{width:'100px'}}/></CustomFunctionButton>
        
        <p className='text-light'>(Click me to get a joke)</p>
        <br></br><br></br>
        <div className='d-flex align-items-center justify-content-center text-center'>
            <div id='jokeDiv' className='w-50'></div>
        </div>
        <br></br>
    </div>
  );
}
