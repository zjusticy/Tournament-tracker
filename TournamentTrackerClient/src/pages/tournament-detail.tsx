import {
  Card,
  CardContent,
  //   CardDescription,
  CardHeader,
  CardTitle,
} from "@/features/ui/card";

import { useParams } from "react-router-dom";

import {
  MatchupTable,
  RoundSelector,
  useTournamentDetail,
} from "@/features/tournament-detail";

export function TournamentDetail() {
  const { tournamentId } = useParams<{ tournamentId: string }>();

  const { tournamentDetail } = useTournamentDetail(tournamentId);

  return (
    <div className="max-w-[1200px] m-auto">
      <div className="hidden flex-col md:flex">
        <div className="flex-1 space-y-4 p-8 pt-6">
          <div className="flex items-center justify-between space-y-2">
            <h2 className="text-3xl font-bold tracking-tight">
              {tournamentDetail
                ? tournamentDetail.tournamentName
                : "No tournament found"}{" "}
            </h2>
          </div>

          <div className="grid gap-4 md:grid-cols-2 lg:grid-cols-4"></div>
          <div className="grid gap-4 md:grid-cols-2 lg:grid-cols-7">
            <Card className="col-span-4">
              <CardHeader>
                <div className="flex items-center">
                  <CardTitle>Matchups</CardTitle>
                  <div className="ml-4">
                    <RoundSelector />
                  </div>
                </div>
              </CardHeader>
              <CardContent className="pl-4">
                <MatchupTable
                  matchups={
                    tournamentDetail && tournamentDetail.tournamentMatchups
                  }
                />
              </CardContent>
            </Card>
            <Card className="col-span-3 h-[500px]">
              <CardHeader>
                <CardTitle>Prizes</CardTitle>
              </CardHeader>
              <CardContent>First place: $160</CardContent>
            </Card>
          </div>
        </div>
      </div>
    </div>
  );
}
