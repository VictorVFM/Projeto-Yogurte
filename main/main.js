class MobileNavBar{
    constructor(mobileMenu,navList,navLinks){
        this.mobileMenu = document.querySelector(mobileMenu);
        this.navList = document.querySelector(navList);
        this.navLinks = document.querySelectorAll(navLinks)
        this.activeClass = "active";

        this.handleClick = this.handleClick.bind(this);
    }
    animateLinks(){
        this.navLinks.forEach((link) =>{
            link.style.animation
            ? (link.style.animation = "")
            : (link.style.animation = `navLinkFade 0.5s ease forwards 0.3s`);
        });
    }
    handleClick(){
        this.navList.classList.toggle(this.activeClass);
        this.mobileMenu.classList.toggle(this.activeClass);
        this.animateLinks();
    }

    addClickEvent(){
        this.mobileMenu.addEventListener("click", this.handleClick);
    }
    init(){
        if(this.mobileMenu){
            this.addClickEvent();
        }
        return this;
    }
}
const mobileNavBar = new MobileNavBar(
    ".mobile-menu",".nav-list",".nav-list li",
);
mobileNavBar.init();

 
// function typeWriter(element) {
//     const textArray = element.innerText.split('')
//     element.innerText = ''
//    textArray.forEach((letra, i) =>  {
       
//     setTimeout(() => element.innerText += letra, 60 * i)
    
//    })
  
// }


//      const title = window.document.querySelector('h1')
// typeWriter(title)

