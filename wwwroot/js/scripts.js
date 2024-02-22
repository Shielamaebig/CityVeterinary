// document.body.style.zoom = "80%";

/*=============== LINK ACTIVE ===============*/
const linkColor = document.querySelectorAll('.sidebar-li')
const activeLinks = document.querySelectorAll('.active')
function colorLink(){
    linkColor.forEach(l => l.classList.remove('active'))
    this.classList.add('active')
}

linkColor.forEach(l => l.addEventListener('click', colorLink))
/*=============== SHOW HIDDEN MENU ===============*/
const showMenu = (toggleId, navbarId, mainId) =>{
    const toggle = document.getElementById(toggleId),
    navbar = document.getElementById(navbarId)
    mainP = document.getElementById(mainId);
    if(toggle && navbar && mainP){
        toggle.addEventListener('click', ()=>{
            /* Show menu */
            navbar.classList.toggle('show-menu')
            mainP.classList.toggle('show-main')
            /* Rotate toggle icon */
            toggle.classList.toggle('rotate-icon')
        })
    }
}
showMenu('side-toggle','sidebar', 'main-page')
