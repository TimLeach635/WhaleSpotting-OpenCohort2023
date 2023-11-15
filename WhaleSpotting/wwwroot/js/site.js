

let currentIndex = 0;
  const slides = document.querySelectorAll('.slide');
  const dots = document.querySelectorAll('.dot');
 
  function showSlide(index) {
    slides.forEach((slide) => {
      slide.classList.remove('active');
    });
    dots.forEach((dot) => {
      dot.classList.remove('active');
    });
 
    slides[index].classList.add('active');
    dots[index].classList.add('active');
  }
 
  function firstSlide() {
    currentIndex = 0;
    showSlide(currentIndex);
  }

  function nextSlide() {
    currentIndex = (currentIndex + 1) % slides.length;
    showSlide(currentIndex);
  }
 
  function previousSlide() {
    currentIndex = (currentIndex - 1 + slides.length) % slides.length;
    showSlide(currentIndex);
  }
 
  firstSlide();
 
  setInterval(nextSlide, 5000);
 
 