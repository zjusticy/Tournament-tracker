import useSWR from "swr";

import { TournamentDetailType } from "@/types";
import { axiosInstance } from "@/lib/utils";

export function useTournamentDetail(id: string | undefined) {
  const {
    data: tournamentDetail,
    error,
    mutate,
  } = useSWR<TournamentDetailType>(
    id ? `/api/tournaments/${id}` : null,
    async (url: string) => {
      const res = await axiosInstance.get(url);
      return res.data;
    }
  );

  return {
    tournamentDetail,
    error,
    mutate,
  };
}
