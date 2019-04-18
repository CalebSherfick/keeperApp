import Vue from 'vue'
import Router from 'vue-router'
// @ts-ignore
import Dashboard from './views/Dashboard.vue'
// @ts-ignore
import Login from './views/Login.vue'
// @ts-ignore
import Vaults from './views/Vaults.vue'
// @ts-ignore
import VaultKeeps from './views/VaultKeeps.vue'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'dashboard',
      component: Dashboard
    },
    {
      path: '/login',
      name: 'login',
      component: Login
    },
    {
      path: '/vaults',
      name: 'vaultsView',
      component: Vaults
    },
    {
      path: '/vaults/:vaultId/keeps',
      name: 'vaultKeeps',
      component: VaultKeeps
    },
    {
      path: '/login',
      name: 'login',
      component: Login
    }
  ]
})
