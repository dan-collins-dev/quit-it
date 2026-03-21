<script>
	import { Line } from "svelte-chartjs";
	import {
		Chart as ChartJS,
		Title,
		Tooltip,
		Legend,
		LineElement,
		LinearScale,
		PointElement,
		CategoryScale
	} from "chart.js";

	ChartJS.register(Title, Tooltip, Legend, LineElement, LinearScale, PointElement, CategoryScale);

	const data = {
		labels: ["January", "February", "March", "April", "May", "June", "July"],
		datasets: [
			{
				label: "My First Dataset",
				backgroundColor: "rgb(255, 99, 132)",
				borderColor: "rgb(255, 99, 132)",
				data: [0, 10, 5, 2, 20, 30, 45]
			}
		]
	};
</script>

<article>
	<div>
		<Line {data} />
	</div>
</article>

<style>
	article {
		display: flex;
		flex-direction: column;
		justify-content: space-between;
		background-color: #fff;
		border-radius: 5px;
		box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2);
		padding: 1rem;
		margin: 0.75rem;
	}

	div {
		width: 100%;
	}

	p,
	h2 {
		color: black;
	}
</style>
