// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//const x = document.querySelector(".display-4")
//x.addEventListener("click", (e) => {
//    e.target.style.backgroundColor = "yellow";
//})


function printSomething(data) {
    const promise = new Promise((resolve, reject) => {
        setTimeout(() => { resolve(data) }, 1000)
    })
    return promise;
}

//printSomething("A").then(data => {
//    console.log(data)
//    return printSomething("B")
//}).then(data => {
//    console.log(data)
//}).finally(() => {
//    console.log("end")
//})


    (async () => {
        const data = await printSomething("A")
        console.log(data);
        const data1 = await printSomething("B")
        console.log(data1);
    })();