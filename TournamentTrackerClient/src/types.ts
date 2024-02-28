export type TournamentListType = {
  id: number;
  tournamentName: string;
  entryFee: number;
  kickedOff: boolean;
};

export type prizeType = {
  id: number;
  placeNumber: number;
  placeName: string;
  prizeAmount: number;
  prizePercentage: number;
};

export type entry = {
  id: number;
  teamCompeting: {
    id: number;
    teamName: string;
  };
  score: number;
};

export type matchupType = {
  id: number;
  winner: number;
  matchupRound: number;
  entries: entry[];
};

export type TournamentDetailType = TournamentListType & {
  prizes: prizeType[];
  enteredTeams: { id: number; teamName: string }[];
  tournamentMatchups: matchupType[];
};
