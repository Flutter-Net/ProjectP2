// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const Feed = document.querySelector('#FeedPage');
const FeedContainer = document.querySelector('#FeedContainer')

Feed.addEventListener('load', LoadFeed());

 function LoadFeed(){
    
    console.log('poop')
    // const queryURL =  "http://localhost:5000/post/posts"
    
    // ajax(queryURL)
    
    
    // function pass(res){
    //   res.json().then(function(data){
    //     console.log(data) //options with data here
    //   })
    // }
    // function fail(res){
    //   console.error(res)
    // }
    // function ajax(input){
    //   fetch(input).then(pass,fail)
    // }

    //  will need a second ajax call for users

    const Data = [
        {
            "userId":8,
            "datePosted":"2021-01-26T19:05.3992114",
            "tagIds":null,
            "content":"oldest",
            "entityId":1
        },
        {
            "userId":8,
            "datePosted":"2021-01-26T19:05.3992777",
            "tagIds":null,
            "content":"Is this my first post",
            "entityId":2
        },
        {
            "userId":8,
            "datePosted":"2021-01-26T19:05.3997777",
            "tagIds":null,
            "content":"newest",
            "entityId":3
        }
    ]
    
    for(let i=0;i<Data.length;i++){

        // TODO once making ajax calls add logic to match users to posts, long nested for loop might make for slower load times though will see

        console.log(Data[i].content)
        let post = document.createElement('div')
        post.setAttribute('class','is-post')
        FeedContainer.prepend(post)
        let img = document.createElement('img')
        img.setAttribute('src','../batpost.png')
        img.setAttribute('class','is-post-icon')
        post.appendChild(img)
        let UserName = document.createElement('strong')
        UserName.innerHTML = `UserName`
        post.appendChild(UserName)
        let content = document.createElement('p')
        content.innerHTML = Data[i].content
        post.appendChild(content)
        let CommentBtn = document.createElement('button')
        CommentBtn.setAttribute('class','button is-Flutter')
        CommentBtn.innerHTML = 'Comment'
        post.appendChild(CommentBtn)
        let LikeBtn = document.createElement('button')
        LikeBtn.setAttribute('class','button is-Flutter')
        LikeBtn.innerHTML = 'Like'
        post.appendChild(LikeBtn)
    }

}

