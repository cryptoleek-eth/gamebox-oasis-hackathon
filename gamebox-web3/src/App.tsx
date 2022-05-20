import React from "react"
import { Suspense } from 'react'
import { HashRouter as Router } from 'react-router-dom'
import NavBar from './components/NavBar';
import Routes from './routes';
import Footer from "./components/Footer";

const App: React.FC = () => {
  return (
    <Router>
      <Suspense fallback={null}>
        <NavBar />
        <Routes />
        <Footer />
      </Suspense>
    </Router >
  )
}

export default App;
