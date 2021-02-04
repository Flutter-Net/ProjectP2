// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


// Grabs user name
const user = document.querySelector('#CurrentUser')

// Feed Page Ids
const Feed = document.querySelector('#FeedPage');
const FeedContainer = document.querySelector('#FeedContainer')


// checks for postView
const PostView = document.querySelector('#PostView')

// comment view things
const OGPost = document.querySelector('#OGPost')


// Profile feed
const ProfileFeed = document.querySelector('#ProfileFeed')

// Post ids
const UserName = document.querySelector('#UserName')

// loads users past posts
if (ProfileFeed != null) {
    ProfileFeed.addEventListener('load', LoadProfileFeed());
}

function LoadProfileFeed() {

    let UserName = user.getAttribute('data-user')

    const ProfileUrl = "https://flutterapi.azurewebsites.net/posts/" + UserName

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
                if (data[i].commentOfId != 0) {
                    let commentNotice = document.createElement('strong')
                    commentNotice.innerHTML = 'Comment Post'
                    post.appendChild(commentNotice)
                }
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
    const queryURL = "https://flutterapi.azurewebsites.net/post/posts"
    ajax(queryURL)
    function pass(res) {

        res.json().then(function (data) {


            for (let i = 0; i < data.length; i++) {


                if (data[i].commentOfId == 0) {
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
                    let CommentBtn = document.createElement('a')
                    CommentBtn.setAttribute('class', 'button is-Flutter')
                    CommentBtn.setAttribute('href', `/Post/${data[i].entityId}`)
                    CommentBtn.innerHTML = 'Comment'
                    post.appendChild(CommentBtn)
                    let LikeBtn = document.createElement('a')
                    LikeBtn.setAttribute('class', 'button is-Flutter')
                    LikeBtn.setAttribute('data-postId', data[i].entityId)
                    LikeBtn.innerHTML = 'Like'
                    post.appendChild(LikeBtn)
                    LikeBtn.setAttribute('href', `/Post/Like/${data[i].entityId}`)
                    let DisLikeBtn = document.createElement('a')
                    DisLikeBtn.setAttribute('class', 'button is-Flutter')
                    DisLikeBtn.setAttribute('data-postId', data[i].entityId)
                    DisLikeBtn.setAttribute('href', `/Post/DisLike/${data[i].entityId}`)
                    DisLikeBtn.innerHTML = 'DisLike'
                    post.appendChild(DisLikeBtn)
                }

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


// Post Comments Page
if (PostView != null) {
    PostView.addEventListener('load', LoadComments());
}

function LoadComments() {


    let postId = PostView.getAttribute('data-id')
    console.log(postId)

    // OG Post
    const OGURL = `https://flutterapi.azurewebsites.net/post/${postId}`
    OGajax(OGURL)

    function OGpass(res) {
        res.json().then(function (data) {
            console.log(data)
            let ogpost = document.createElement('div')
            ogpost.setAttribute('class', 'is-post')
            OGPost.prepend(ogpost)
            let content = document.createElement('p')
            content.innerHTML = data.content
            ogpost.appendChild(content)

        }).then(
            ajax(queryURL)

        )
    }

    function OGajax(input) {
        fetch(input, {
            method: "GET",
            headers: {
                'Content-Type': 'application/json'
            }
        }).then(OGpass, fail)
    }

    // Comments
    const queryURL = "https://flutterapi.azurewebsites.net/post/" + postId + "/comments"
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
                let LikeBtn = document.createElement('a')
                LikeBtn.setAttribute('class', 'button is-Flutter')
                LikeBtn.setAttribute('data-postId', data[i].entityId)
                LikeBtn.innerHTML = 'Like'
                post.appendChild(LikeBtn)
                LikeBtn.setAttribute('href', `/Post/Like/${data[i].entityId}`)
                let DisLikeBtn = document.createElement('a')
                DisLikeBtn.setAttribute('class', 'button is-Flutter')
                DisLikeBtn.setAttribute('data-postId', data[i].entityId)
                DisLikeBtn.setAttribute('href', `/Post/DisLike/${data[i].entityId}`)
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


