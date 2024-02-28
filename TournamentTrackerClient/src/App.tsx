// import reactLogo from "./assets/react.svg";
// import viteLogo from "/vite.svg";

import { Route, Routes } from "react-router-dom";

// import { CardUpdate, MemoryBoard, Intro, Auth } from "@/pages";

import { TournamentDetail, TournamentList } from "@/pages";

function App() {
  return (
    <>
      <Routes>
        <Route path="/" element={<TournamentList />} />
        <Route
          path="/tournament/:tournamentId"
          element={<TournamentDetail />}
        />
      </Routes>
    </>
  );
}

export default App;
