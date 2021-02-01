// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// Feed Page Ids
const Feed = document.querySelector('#FeedPage');
const FeedContainer = document.querySelector('#FeedContainer')
// Login Page Ids
const UserNameInput = document.querySelector('#UserNameInput')
const PasswordInput = document.querySelector('#PasswordInput')
const LoginBtn = document.querySelector('#LoginBtn')

// Logged in data value 
const CurrentUser = document.querySelector('#CurrentUser')

// Profile feed
const ProfileFeed = document.querySelector('#ProfileFeed')

// Post ids
const PostBtn = document.querySelector('#PostBtn')
const UserId = document.querySelector('#UserId')

// loads users past posts
if (ProfileFeed != null) {
    ProfileFeed.addEventListener('load', LoadProfileFeed());
}

function LoadProfileFeed() {

    // this will give the currently logged in user name for queries
    const user = CurrentUser.dataset.user
    console.log(user)
    const ProfileUrl = "https://localhost:6001/user/"+user+"/posts"

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
                img.setAttribute('src', '../batpost.png')
                img.setAttribute('class', 'is-post-icon')
                post.appendChild(img)
                let UserName = document.createElement('strong')
                UserName.innerHTML = `${user}`
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

    let UserString = CurrentUser.getAttribute('data-user')
    let queryUserURL = `https://localhost:6001/user/${UserString}`

    
    
    idajax(queryUserURL)

    console.log(UserString)

    function pass2(res) {
        console.log(res)
    
        res.json().then(function (data) {
            console.log(`id:${data.entityId}`) 
            UserId.value = data.entityId

            
                       
        })
    }
    function fail2(res) {
        console.error(res)
    }
    function idajax(input) {
        fetch(input, {
            method: "GET",
            headers: {
                'Content-Type': 'application/json'
            }
        }).then(pass2, fail2)
    }
   

   


}


// loads feed page
if (Feed != null) {
    Feed.addEventListener('load', LoadFeed());
}

function LoadFeed() {

    let users = []
    // users for feed
    const userUrl ="https://localhost:6001/users"
    userajax(userUrl)
    function userpass(res){
        console.log(res)
        res.json()
        .then(function(data){
        users = data        
        console.log(users)
        })
    }

    // Posts for feed
    const queryURL = "https://localhost:6001/post/posts"
    ajax(queryURL)
    function pass(res) {
        

        res.json().then(function (data) {
            console.log(users)

            for (let i = 0; i < data.length; i++) {
                
                let u = users.filter(u => u.entityId == data[i].userId)
                console.log(u[0].name)

                // TODO once making ajax calls add logic to match users to posts, long nested for loop might make for slower load times though will see
                let post = document.createElement('div')
                post.setAttribute('class', 'is-post')
                FeedContainer.prepend(post)
                let img = document.createElement('img')
                img.setAttribute('src', '../batpost.png')
                img.setAttribute('class', 'is-post-icon')
                post.appendChild(img)
                let UserName = document.createElement('strong')
                UserName.innerHTML = `${u[0].name}`
                post.appendChild(UserName)
                let content = document.createElement('p')
                content.innerHTML = data[i].content
                post.appendChild(content)
                let CommentBtn = document.createElement('button')
                CommentBtn.setAttribute('class', 'button is-Flutter')
                CommentBtn.innerHTML = 'Comment'
                post.appendChild(CommentBtn)
                let LikeBtn = document.createElement('button')
                LikeBtn.setAttribute('class', 'button is-Flutter')
                LikeBtn.innerHTML = 'Like'
                post.appendChild(LikeBtn)
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
    function userajax(input) {
        fetch(input, {
            method: "GET",
            headers: {
                'Content-Type': 'application/json'
            }
        }).then(userpass , fail)
    }
 

   

}
if (LoginBtn != null) {
    LoginBtn.addEventListener('click', function () {
        event.preventDefault()
        Login()

    });
}

function Login() {
    const queryURL =  "https://localhost:6001/users"

    ajax(queryURL)

    function pass(res) {
        console.log(res)
    
        res.json().then(function (data) {
            console.log(data) //options with data here
            let user = data.find(user => user.name == UserNameInput.value)
            

    console.log(user)

    if (PasswordInput.value == user.password) {
        window.location.href = `/Profile/${UserNameInput.value}/${user.entityId}`
    }
    else {
        window.location.href = '/LoginFailed'
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


