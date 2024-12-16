import { createRouter, createWebHistory } from 'vue-router';
import HomePage from '../components/HomePage.vue';
import DeckCreatePage from '../components/DeckCreatePage.vue';
import DeckListPage from '../components/DeckListPage.vue';
import DeckDetailsPage from '../components/DeckDetailsPage.vue';

const routes = [
    {path: '/', name: 'Home', component: HomePage,},
    {path: '/deck-create', name: 'DeckCreatePage', component: DeckCreatePage,},
    {path: '/deck-list', name: 'DeckListPage', component: DeckListPage },
    { path: '/deck-details/:deckId/:deckName', name: 'DeckDetailsPage', component: DeckDetailsPage },
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;
