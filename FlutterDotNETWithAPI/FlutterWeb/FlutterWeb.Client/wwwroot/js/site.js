// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


// Grabs user name
const user = document.querySelector('#CurrentUser')

// Feed Page Ids
const Feed = document.querySelector('#FeedPage');
const FeedContainer = document.querySelector('#FeedContainer')




// Profile feed
const ProfileFeed = document.querySelector('#ProfileFeed')

// Post ids
const PostBtn = document.querySelector('#PostBtn')
const UserName = document.querySelector('#UserName')

// loads users past posts
if (ProfileFeed != null) {
    ProfileFeed.addEventListener('load', LoadProfileFeed());
}

function LoadProfileFeed() {

    let UserName = user.getAttribute('data-user')
    
    const ProfileUrl = "https://localhost:6001/posts/" + UserName

    ajax(ProfileUrl)

    function pass(res) {
        console.log(res)

        res.json().then(function (data) {
            console.log(data)
            for (let i = 0; i < data.length; i++) {

                let post = document.createElement('div')
                post.setAttribute('class', 'is-post')
                ProfileFeed.prepend(post)
                let img = document.createElement('img')
                img.setAttribute('src', '../../batpost.png')
                img.setAttribute('class', 'is-post-icon')
                post.appendChild(img)
                let UserName = document.createElement('strong')
                UserName.innerHTML = data[i].userName
                post.appendChild(UserName)
                let content = document.createElement('p')
                content.innerHTML = data[i].content
                post.appendChild(content)
            }

        })
    }
    function fail(res) {
        console.error(res)
    }
    function ajax(input) {
        fetch(input, {
            method: "GET",
            headers: {
                'Content-Type': 'application/json'
            }
        }).then(pass, fail)
    }
   

}


// loads feed page
if (Feed != null) {
    Feed.addEventListener('load', LoadFeed());
}

function LoadFeed() {


    // Posts for feed
    const queryURL = "https://localhost:6001/post/posts"
    ajax(queryURL)
    function pass(res) {

        res.json().then(function (data) {
            

            for (let i = 0; i < data.length; i++) {

                console.log(data[i])


                let post = document.createElement('div')
                post.setAttribute('class', 'is-post')
                FeedContainer.prepend(post)
                let img = document.createElement('img')
                img.setAttribute('src', '../../batpost.png')
                img.setAttribute('class', 'is-post-icon')
                post.appendChild(img)
                let UserName = document.createElement('strong')
                UserName.innerHTML = data[i].userName
                post.appendChild(UserName)
                let content = document.createElement('p')
                content.innerHTML = data[i].content
                post.appendChild(content)
                let likes = document.createElement('p')
                likes.innerHTML = ` Likes: ${data[i].likeScore}`
                post.appendChild(likes)
                let CommentBtn = document.createElement('button')
                CommentBtn.setAttribute('class', 'button is-Flutter')
                CommentBtn.innerHTML = 'Comment'
                post.appendChild(CommentBtn)
                let LikeBtn = document.createElement('a')
                LikeBtn.setAttribute('class', 'button is-Flutter')
                LikeBtn.setAttribute('data-postId',data[i].entityId)
                LikeBtn.innerHTML = 'Like'
                post.appendChild(LikeBtn)
                LikeBtn.setAttribute('href',`/Post/Like/${data[i].entityId}`)
                let DisLikeBtn = document.createElement('a')
                DisLikeBtn.setAttribute('class', 'button is-Flutter')
                DisLikeBtn.setAttribute('data-postId',data[i].entityId)
                DisLikeBtn.setAttribute('href',`/Post/DisLike/${data[i].entityId}`)
                DisLikeBtn.innerHTML = 'DisLike'
                post.appendChild(DisLikeBtn)
            }

        })
    }
    function fail(res) {
        console.error(res)
    }
    function ajax(input) {
        fetch(input, {
            method: "GET",
            headers: {
                'Content-Type': 'application/json'
            }
        }).then(pass, fail)
    }

}









// ajax functions for queries
// function pass(res) {
//     console.log(res)

//     res.json().then(function (data) {
//         console.log(data) //options with data here

//     })
// }
// function fail(res) {
//     console.error(res)
// }
// function ajax(input) {
//     fetch(input, {
//         method: "GET",
//         headers: {
//             'Content-Type': 'application/json'
//         }
//     }).then(pass, fail)
// }


