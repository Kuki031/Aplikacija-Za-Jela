"use strict"

window.addEventListener('DOMContentLoaded', () => {

    const mainDiv = document.querySelector('.main');
    const injectedDiv = document.querySelector('.injected-div');
    const injectedDiv2 = document.querySelector('.injected-div2');
    mainDiv.classList.add('hidden');
    const errorSpan = document.querySelector('#error-span');
    let input = document.querySelector('.input');
    

    const btnStart = document.querySelector('#dohvati-recept');
    const generateIngredients = function (data) {
        injectedDiv2.innerHTML = `
         <h3>Ime jela: <span>${data.strMeal}</span></h3>
         <h3>Porijeklo: <span>${data.strArea}</span></h3>
         <h3>Kategorija: <span>${data.strCategory}</span></h3>
         <img class="img" src="${data.strMealThumb}">
         <h3>Recept: </h3>
         <p id="recept">${data.strInstructions}</p>
         <p><a href="${data.strYoutube}">Tutorijal za jelo ${data.strMeal}</a></p>
        
        `
        injectedDiv.innerHTML = `
            <h3>Sastojci:</h3>
        <p>${data.strIngredient1}-----<span>${data.strMeasure1}</span></p>
        <p>${data.strIngredient2}-----<span>${data.strMeasure2}</span></p>
        <p>${data.strIngredient3}-----<span>${data.strMeasure3}</span></p>
        <p>${data.strIngredient4}-----<span>${data.strMeasure4}</span></p>
        <p>${data.strIngredient5}-----<span>${data.strMeasure5}</span></p>
        <p>${data.strIngredient6}-----<span>${data.strMeasure6}</span></p>
        <p>${data.strIngredient7}-----<span>${data.strMeasure7}</span></p>
        <p>${data.strIngredient8}-----<span>${data.strMeasure8}</span></p>
        <p>${data.strIngredient9}-----<span>${data.strMeasure9}</span></p>
        <p>${data.strIngredient10}-----<span>${data.strMeasure10}</span></p>
        <p>${data.strIngredient11}-----<span>${data.strMeasure11}</span></p>
        <p>${data.strIngredient12}-----<span>${data.strMeasure12}</span></p>
        <p>${data.strIngredient13}-----<span>${data.strMeasure13}</span></p>
        `
    }
   
 

    const getMealFunction = async function (meal) {
        try {
        
            if (input.value === '') throw new Error('Input prazan.');
      
            const fetchUrl = await fetch(`https://www.themealdb.com/api/json/v1/1/search.php?s=${meal}`);
            if (!fetchUrl.ok) throw new Error('Ne mogu dohvatiti traženo jelo!');

            const getData = await fetchUrl.json();
            generateIngredients(getData.meals[0]);
            console.log(getData);
            errorSpan.textContent = '';

            }
            catch (err) {
                errorSpan.textContent = err.message;
            }
            finally {
            setTimeout(() => { console.log('API_url: https://www.themealdb.com') }, 50);
        }
    }

    btnStart.addEventListener('click', () => {

        mainDiv.classList.remove('hidden');
        getMealFunction(input.value);
        input.value = '';
    })
})



