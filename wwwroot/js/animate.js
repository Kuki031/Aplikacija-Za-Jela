window.addEventListener('DOMContentLoaded', () => {

    const animateText = `Prezime i ime: Kukučka Luka,

    Ekonomski fakultet u Osijeku,

    Smjer: Poslovna Informatika,

    3.godina preddiplomskog sveučilišnog studija.`
    let count = 0;
    const animateFunction = function (words) {
        count++;
        const animatePar = document.querySelector('#animate-p');
        animatePar.textContent = words.slice(0, count);
    }
    setInterval(() => {
        animateFunction(animateText);
    }, 20)
    count === animateText.length ? clearInterval(animateFunction) : count;
})
