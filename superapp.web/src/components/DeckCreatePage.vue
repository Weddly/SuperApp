<template>
  <div class="form-page">
    <h1 class="title">Create New Deck</h1>
    <div v-if="isLoading" class="loading-spinner">Creating deck...</div>
    <form @submit.prevent="createDeck" class="deck-form" v-if="!isLoading">
      <div class="form-group">
        <label for="owner">Owner</label>
        <input
          type="text"
          id="owner"
          v-model="owner"
          placeholder="Enter owner name"
          required
        />
      </div>
      <div class="form-group">
        <label for="deck-name">Deck Name</label>
        <input
          type="text"
          id="deck-name"
          v-model="deckName"
          placeholder="Enter deck name"
          required
        />
      </div>
      <div class="button-group">
        <button type="button" class="back-button" @click="goBack">Back</button>
        <button type="submit" class="action-button">Create</button>
      </div>
    </form>
  </div>
</template>

<script>
import axios from "axios";

export default {
  name: "DeckCreatePage",
  data() {
    return {
      owner: "",
      deckName: "",
      isLoading: false, 
    };
  },
  methods: {
    async createDeck() {
      try {
        this.isLoading = true 
        const response = await axios.post(
          "http://localhost:5001/Deck/CreateDeck",
          {
            Owner: this.owner,
            Name: this.deckName,
          }
        );

        console.log("Deck created successfully:", response.data);
        alert(`Deck "${this.deckName}" created successfully!`);
        this.openDeck(response.data);
      } catch (error) {
        console.error("Error creating deck:", error);
        alert("Failed to create deck. Please try again.");
        this.isLoading = false 
      }
    },
    goBack() {
      this.$router.push("/");
    },
    openDeck(data) {
      if (data.id) {
        this.$router.push({
          name: "DeckDetailsPage",
          params: { deckId: data.id, deckName: data.name },
        });
      }
    },
  },
};
</script>

<style scoped>
.form-page {
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  height: 100vh;
  background: linear-gradient(
    135deg,
    #4b0082,
    #000
  ); /* Dark purple to black gradient */
  color: white;
}

.title {
  font-size: 2.5rem;
  font-weight: bold;
  margin-bottom: 2rem;
}

.deck-form {
  display: flex;
  flex-direction: column;
  gap: 1.5rem;
  width: 300px;
}

.form-group {
  display: flex;
  flex-direction: column;
}

label {
  font-size: 1rem;
  margin-bottom: 0.5rem;
}

input {
  padding: 0.8rem;
  font-size: 1rem;
  border: none;
  border-radius: 5px;
  outline: none;
}

.button-group {
  display: flex;
  justify-content: space-between;
}

.action-button {
  padding: 0.8rem 1.5rem;
  font-size: 1rem;
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

.back-button {
  padding: 0.8rem 1.5rem;
  font-size: 1rem;
  font-weight: bold;
  color: #fff;
  background-color: #6c757d;
  border: none;
  border-radius: 5px;
  cursor: pointer;
  transition: background-color 0.3s ease;
}

.back-button:hover {
  background-color: #5a6268;
}

/* Loading Spinner */
.loading-spinner {
  text-align: center;
  margin-top: 2rem;
  margin-bottom: 2rem;
  font-size: 1.5rem;
  color: white;
}
</style>
