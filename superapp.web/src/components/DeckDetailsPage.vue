<template>
  <div class="deck-details-page">
    <h1 class="title">{{ $route.params.deckName }}</h1>

    <div v-if="isLoading" class="loading-spinner">Loading cards...</div>

    <div class="card-container" v-else-if="cards.length">
      <div 
        class="card" 
        v-for="card in cards" 
        :key="card.id"
      >
        <img :src="card.image" alt="Card Image" />
        <h2>{{ card.codeName }}</h2>
      </div>
    </div>

    <div v-else class="no-decks-message">
      No cards available.
    </div>
    
    <div class="button-group">
      <button class="back-button" @click="goBack">Back</button>
      <button class="get-prize-button" @click="getPrizeCard">Prize Card</button>
    </div>
  </div>
</template>

<script>
import axios from "axios";


export default {
  name: "DeckDetailsPage",
  props: {
    deckId: {
      type: String,
      required: true,
    },
    deckName: {
      type: String,
      required: true,
    },
  },
  data() {
    return {
      cards: [],
      isLoading: true,
      id: this.$route.params.deckId 
    };
  },
  async created() {
    await this.fetchDecks();
  },
  methods: {
    async fetchDecks() {
      try {
        const response = await axios.get(
          `http://localhost:5001/SuperHero/GetHeroesListByDeckId/${this.id}`,
          { params: { _t: Date.now() } });
        this.cards = response.data;
      } catch (error) {
        console.error("Error fetching cards:", error);
        alert("Failed to load cards. Please try again.");
      } finally {
        this.isLoading = false;
      }
    },
    goBack() {
      this.$router.push("/deck-list");
    },
    async getPrizeCard() {
      this.isLoading = true;
      try {
        await axios.get(
          `http://localhost:5001/Deck/AddPrizeCardToDeck/${this.id}`,
          { params: { _t: Date.now() } });
        this.fetchDecks()
      } catch (error) {
        console.error("Error fetching cards:", error);
        alert("Failed to get prize. Please try again.");
      }
    },
  },
};
</script>

<style scoped>
.deck-details-page {
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  min-height: 100vh;
  background: linear-gradient(
    135deg,
    #4b0082,
    #000
  );
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

.button-group {
  margin-top: 30px;
  display: flex;
  justify-content: space-between;
}

.card-container {
  display: flex;
  flex-wrap: wrap;
  justify-content: center;
  gap: 20px;
}

.card {
  width: 200px;
  text-align: center;
  background-color: #1e90ff66;
  border-radius: 4px;
  box-shadow: 7px 6px 0 0 darkblue, 7px 7px 0 4px black;
}

.card img {
  width: 90%;
  padding: 10px 5px 0px 5px;
  height: auto;
}

.back-button {
  padding: 0.8rem 1.5rem;
  font-size: 1rem;
  font-weight: bold;
  color: white;
  background-color: #6c757d;
  border: none;
  border-radius: 5px;
  cursor: pointer;
  margin-bottom: 2rem;
  width: 150px;
}

.back-button:hover {
  background-color: #5a6268;
}

.get-prize-button {
  background-color: #28a745;
  padding: 0.8rem 1.5rem;
  font-size: 1rem;
  font-weight: bold;
  color: white;
  border: none;
  border-radius: 5px;
  cursor: pointer;
  margin-bottom: 2rem;
  margin-left: 2rem;
  width: 150px;
}

.get-prize-button:hover {
  background-color: #05c73c;
}
</style>
