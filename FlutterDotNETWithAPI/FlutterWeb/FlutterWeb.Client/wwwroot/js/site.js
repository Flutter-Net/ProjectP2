// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const button = document.querySelector("#test")
const queryURL =  "/Tags/66"

button.addEventListener('click',function(){
let query = `${queryURL}`
ajax(query)

})

function pass(res){
  res.json().then(function(data){
    console.log(data)
  })
}
function fail(res){
  console.error(res)
}
function ajax(input){
  fetch(input).then(pass,fail)
}

// ---------------------------------------------------
let PostText = ""
    const BadWords = ['shit', 'ass', 'fuck', 'gay', 'damn', 'bastard', 'bitch', 'cunt', 'poop', 'nigg', 'cock', 'dick', 'retard', 'pussy']


    const postbutton = document.querySelector("#postButton")


    const HandleText = () => {


        let str = PostText.toLowerCase()
        let bad = false
        for (let i = 0; i < BadWords.length; i++) {
            if (str.includes(BadWords[i])) {
                bad = true
            }
        }
        if (bad === true) {
            alert('Post contains inappropriate content')

        }
        else {
            Post()
        }

    }

    const UpdatePostTex = () => {
        PostText = document.querySelector("#PostText").value;
    }


    const Post = () => {
        alert(PostText)
        console.log(PostText)
    }
