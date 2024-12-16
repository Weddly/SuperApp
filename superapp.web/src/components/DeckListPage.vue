<template>
  <div class="deck-list-page">
    <h1 class="title">Available Decks</h1>
    
    <div v-if="isLoading" class="loading-spinner">Loading decks...</div>

    <table v-else-if="decks.length" class="deck-table">
      <thead>
        <tr>
          <th>Deck Name</th>
          <th>Owner</th>
          <th>Actions</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="deck in decks" :key="deck.id">
          <td>{{ deck.name }}</td>
          <td>{{ deck.owner }}</td>
          <td class="actions">
            <button class="icon-button open" @click="openDeck(deck.id)">
              <span class="material-icons">folder_open</span>
            </button>
            <button class="icon-button delete" @click="deleteDeck(deck.id)">
              <span class="material-icons">delete</span>
            </button>
          </td>
        </tr>
      </tbody>
    </table>

    <div v-else class="no-decks-message">
      No decks available. Please create one.
    </div>

    <button class="back-button" @click="goBack">Back</button>
  </div>
</template>

<script>
import axios from "axios";

export default {
  name: "DeckListPage",
  data() {
    return {
      decks: [],
       isLoading: true, 
    };
  },
  async created() {
    await this.fetchDecks();
  },
  methods: {
    async fetchDecks() {
      try {
        const response = await axios.get(
          "http://localhost:5001/Deck/GetAllDecks"
        );
        this.decks = response.data; // Store the fetched decks
      } catch (error) {
        console.error("Error fetching decks:", error);
        alert("Failed to load decks. Please try again.");
      } finally {
        this.isLoading = false;
      }
    },
    openDeck(deckId) {
      const selectedDeck = this.decks.find((deck) => deck.id === deckId);
      if (selectedDeck) {
        this.$router.push({
          name: "DeckDetailsPage",
          params: { deckId: selectedDeck.id, deckName: selectedDeck.name },
        });
      }
    },
    async deleteDeck(deckId) {
      try {
        this.isLoading = true;
        await axios
          .delete(`http://localhost:5001/Deck/DeleteDeck/${deckId}`)
          .then(() => {
            this.decks = this.decks.filter((deck) => deck.id !== deckId);
            alert("Deck deleted successfully.");
          })
      } catch (error) {
        console.error("Error deleting deck:", error);
        alert("Failed to delete the deck. Please try again.");
      } finally {
        this.isLoading = false
      }
    },
    goBack() {
      this.$router.push("/");
    },
  },
};
</script>

<style scoped>

.deck-list-page {
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  min-height: 100vh;
  background: linear-gradient(135deg, #4b0082, #000);
  color: white;
}

.title {
  font-size: 2.5rem;
  margin-bottom: 2rem;
}

.deck-table {
  width: 80%;
  border-collapse: collapse;
  margin-bottom: 2rem;
}

.deck-table th,
.deck-table td {
  border: 1px solid #ddd;
  padding: 1rem;
  text-align: left;
  color: white;
}

.deck-table th {
  background-color: #333;
  font-weight: bold;
}

.deck-table tbody tr:nth-child(even) {
  background-color: #444;
}

.deck-table tbody tr:hover {
  background-color: #555;
}

.actions {
  display: flex;
  gap: 0.5rem;
}

.icon-button {
  display: flex;
  align-items: center;
  justify-content: center;
  padding: 0.5rem;
  font-size: 1.2rem;
  color: white;
  background: none;
  border: none;
  cursor: pointer;
}

.icon-button.open {
  color: #4caf50;
}

.icon-button.delete {
  color: #f44336;
}

.icon-button:hover {
  transform: scale(1.1);
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
}

.back-button:hover {
  background-color: #5a6268;
}

.loading-spinner {
  text-align: center;
  margin-top: 2rem;
  margin-bottom: 2rem;
  font-size: 1.5rem;
  color: white;
}

.no-decks-message {
  text-align: center;
  margin-top: 2rem;
  margin-bottom: 2rem;
  color: white;
}

@import url("https://fonts.googleapis.com/icon?family=Material+Icons");
</style>
