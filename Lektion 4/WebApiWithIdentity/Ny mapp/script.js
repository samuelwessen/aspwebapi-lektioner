let regbutton = document.getElementById('register')
let loginbutton = document.getElementById('login')
let getbutton = document.getElementById('get')
let logoutbutton = document.getElementById('logout')

let registerobj = {
    firstName: "Anna",
    lastName: "Andersson",
    email: "anna@andersson.com",
    password: "BytMig123!"
}


let loginobj = {    
    email: registerobj.email,
    password: registerobj.password
}

let token


regbutton.addEventListener("click", (e) => {
    let json = JSON.stringify(registerobj)
    console.log(json)


    fetch("https://localhost:44367/api/Users/register", {
        method: 'POST',
        headers: {
            'Accept': 'application/json, text/plain',
            'Content-Type': 'application/json;charset=UTF-8'
        },
        body: json
    })
    .then(res => res.json())
    .then(data => console.log(data))
    .catch(error => console.log(error))    
})


loginbutton.addEventListener("click", (e) => {
    let json = JSON.stringify(loginobj)
    console.log(json)


    fetch("https://localhost:44367/api/Users/login", {
        method: 'POST',
        headers: {
            'Accept': 'application/json, text/plain',
            'Content-Type': 'application/json;charset=UTF-8'
        },
        body: json
    })
    .then(res => res.json())
    .then(data => {
        token = data.token

        console.log(token)
    })
    .catch(error => console.log(error))    
})


loginbutton.addEventListener("click", (e) => {
    let json = JSON.stringify(loginobj)
    console.log(json)


    fetch("https://localhost:44367/api/Users/login", {
        method: 'POST',
        headers: {
            'Accept': 'application/json, text/plain',
            'Content-Type': 'application/json;charset=UTF-8'
        },
        body: json
    })
    .then(res => res.json())
    .then(data => {
        token = data.token

        localStorage.setItem("token", token)
        sessionStorage.setItem("token", token)

        console.log(token)
    })
    .catch(error => console.log(error))    
})



getbutton.addEventListener("click", (e) => {
    token = sessionStorage.getItem("token")

    fetch("https://localhost:44367/api/Users", {
        method: 'GET',
        headers: {
            'Accept': 'application/json, text/plain',
            'Content-Type': 'application/json;charset=UTF-8',
            'Authorization': `Bearer  ${token}`,
        },        
    })
    .then(res => res.json())
    .then(data => {
        document.getElementById('users').innerHTML = ""

        for(let user of data) {
            document.getElementById('users').innerHTML += `<p>${user.firstName} ${user.lastName}</p>`
        }
    })    
    .catch(error => console.log(error))    
})




logoutbutton.addEventListener("click", (e) => {
    token = ""
    users.innerHTML = ""
    sessionStorage.removeItem("token")
    localStorage.removeItem("token")      
})