<template>
  <div class="home-page">
    <h1 class="title">Super App</h1>
    <h2 class="subtitle">Card Board</h2>
    <div class="button-container">
      <button class="action-button" @click="goToDeckCreate">New Deck</button>
      <button class="action-button" @click="goToDeckList">
        Available Decks
      </button>
    </div>
  </div>
</template>

<script>
export default {
  name: "HomePage",
  methods: {
    goToDeckCreate() {
      this.$router.push("/deck-create");
    },
    goToDeckList() {
      this.$router.push("/deck-list");
    },
  },
};
</script>

<style scoped>
.home-page {
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  height: 100vh;
  background: linear-gradient(
    135deg,
    #4b0082,
    #000
  );
  color: white;
}
.subtitle{
  font-size: 3rem;
  font-weight: bold;
  text-align: center;
  color: #fff;
  margin-top: 0px;
}

.title {
  font-size: 4rem;
  font-weight: bold;
  text-transform: uppercase;
  text-align: center;
  margin-bottom: 0px;
  background: linear-gradient(
    90deg,
    #ff8c00,
    #ffd700,
    #00ff00,
    #00bfff,
    #ff00ff
  );
  background-clip: text;
  -webkit-background-clip: text;
  animation: glow 2s infinite alternate;
}

@keyframes glow {
  0% {
    text-shadow: 0 0 5px #ffd700, 0 0 10px #ffd700, 0 0 20px #ff8c00,
      0 0 30px #ff8c00;
  }
  100% {
    text-shadow: 0 0 10px #00bfff, 0 0 20px #00bfff, 0 0 30px #00ff00,
      0 0 40px #00ff00;
  }
}

.button-container {
  display: flex;
  flex-direction: column;
  gap: 1rem; /* Spacing between buttons */
}

.action-button {
  padding: 1rem 2rem;
  font-size: 1.2rem;
  font-weight: bold;
  color: #fff;
  background-color: #f00;
  border: none;
  border-radius: 5px;
  cursor: pointer;
  transition: background-color 0.3s ease;
}

.action-button:hover {
  background-color: #0056b3;
}
</style>
