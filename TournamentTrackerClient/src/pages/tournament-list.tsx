// import { CardUpdate, MemoryBoard, Intro, Auth } from "@/pages";

import { DataTable, useTournamentList } from "@/features/data-table";

export const TournamentList = () => {
  const { tournamentList } = useTournamentList();

  return (
    <div className="flex items-center justify-center w-full ">
      <div className="hidden h-full flex-1 flex-col space-y-8 p-8  max-w-[600px] md:flex ">
        <div className="flex items-center justify-between space-y-2">
          <div>
            <h2 className="text-2xl font-bold tracking-tight">Welcome back!</h2>
            <p className="text-muted-foreground">
              Here&apos;s the list of all tournaments! 🏆
            </p>
          </div>
        </div>
        <DataTable data={tournamentList} />
      </div>
    </div>
  );
};
