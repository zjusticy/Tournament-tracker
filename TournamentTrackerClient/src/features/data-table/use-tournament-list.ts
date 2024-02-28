import useSWR from "swr";

import { TournamentListType } from "@/types";
import { axiosInstance } from "@/lib/utils";

export function useTournamentList() {
  const {
    data: tournamentList,
    error,
    mutate,
  } = useSWR<TournamentListType[]>("/api/tournaments", async (url: string) => {
    const res = await axiosInstance.get(url);
    return res.data;
  });

  return {
    tournamentList,
    error,
    mutate,
  };
}
