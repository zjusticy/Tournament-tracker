import { useNavigate } from "react-router-dom";

import {
  Table,
  TableBody,
  TableCell,
  TableHead,
  TableHeader,
  TableRow,
} from "@/features/ui/table";

import { TournamentListType } from "@/types";

export function DataTable({
  data,
}: {
  data: TournamentListType[] | undefined;
}) {
  const navigate = useNavigate();

  const onClickedHandler = (id: number) => {
    navigate(`/tournament/${id}`);
  };

  return (
    <Table>
      <TableHeader>
        <TableRow>
          <TableHead>Name</TableHead>
          {/* <TableHead>Status</TableHead>
          <TableHead>Method</TableHead> */}
          <TableHead className="text-right w-[100px]">Status</TableHead>
        </TableRow>
      </TableHeader>
      <TableBody>
        {data &&
          data.map((tournament) => (
            <TableRow key={tournament.id}>
              <TableCell
                className="font-medium"
                onClick={() => onClickedHandler(tournament.id)}
              >
                {tournament.tournamentName}
              </TableCell>
              {/* <TableCell>{invoice.paymentStatus}</TableCell>
            <TableCell>{invoice.paymentMethod}</TableCell> */}
              <TableCell className="text-right">
                {tournament.kickedOff ? "started" : "draft"}
              </TableCell>
            </TableRow>
          ))}
      </TableBody>
    </Table>
  );
}
