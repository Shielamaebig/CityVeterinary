document.body.style.zoom = "90%";

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
