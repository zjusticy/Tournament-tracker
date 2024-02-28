import {
  Table,
  TableBody,
  TableCell,
  TableHead,
  TableHeader,
  TableRow,
} from "@/features/ui/table";

import { matchupType } from "@/types";

export function MatchupTable({
  matchups,
}: {
  matchups: matchupType[] | undefined;
}) {
  return (
    <Table>
      <TableHeader>
        <TableRow>
          <TableHead>Name</TableHead>
          <TableHead className="text-right w-[100px]">Winner</TableHead>
        </TableRow>
      </TableHeader>
      <TableBody>
        {matchups &&
          matchups.map((matchup) => {
            let matchupName = "TBD";
            if (matchup.entries.length !== 0) {
              const curNames = [];
              let emptyFlag = true;
              for (const entry of matchup.entries) {
                if (entry.teamCompeting) {
                  emptyFlag = false;
                  curNames.push(entry.teamCompeting.teamName);
                } else curNames.push("TBD");
              }

              if (!emptyFlag) matchupName = curNames.join(" vs ");
            }

            return (
              <TableRow key={matchup.id}>
                <TableCell className="font-medium">{matchupName}</TableCell>
                {/* <TableCell>{invoice.paymentStatus}</TableCell>
              <TableCell>{invoice.paymentMethod}</TableCell> */}
                <TableCell className="text-right">
                  {matchup.winner ?? "TBD"}
                </TableCell>
              </TableRow>
            );
          })}
      </TableBody>
    </Table>
  );
}
