let currentIndex = 0;
const slides = document.querySelectorAll('.recent-photos__slide');
  
function showSlide(index) {
  slides.forEach((slide) => {
    slide.classList.remove('recent-photos__active');
  });
  slides[index].classList.add('recent-photos__active');
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

function deleteSighting(sightingId)
{
  fetch(`/admin/sighting/${sightingId}`, {
    method: "DELETE",
  });
}
