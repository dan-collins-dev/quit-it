<script>
	import { onMount } from "svelte";
	import trophyIconSrc from "$lib/assets/trophy-svgrepo-com.svg";

	let loaded = $state(null);
	let error = $state(null);
	let data = $state([]);
	let lastLog = $derived(data[data.length - 1]);

	async function getLogs() {
		try {
			const res = await fetch("http://localhost:5150/api/logs");
			const data = await res.json();
			return data;
		} catch (error) {
			console.error(error);
		}
	}

	function utcDaysSince(timestampMs) {
		const now = new Date();
		const last = new Date(timestampMs);

		const todayUTC = Date.UTC(now.getUTCFullYear(), now.getUTCMonth(), now.getUTCDate());
		const lastUTC = Date.UTC(last.getUTCFullYear(), last.getUTCMonth(), last.getUTCDate());

		return Math.floor((todayUTC - lastUTC) / 86400000);
	}

	onMount(async () => {
		try {
			data = await getLogs();
			loaded = true
		} catch (err) {
			error = err.message
		}
	});
</script>

{#if loaded}
	<article class="dashboard-card">
		<h2>Current Streak</h2>
		<div class="logo-container">
			<img class="cig-logo" src={trophyIconSrc} alt="" />
		</div>
		<p class="card-number">{utcDaysSince(lastLog?.date)}</p>
		<p>Last cigarette smoked on {new Date(lastLog?.date).toLocaleDateString()}</p>
	</article>
{:else if loaded === false}
	<article class="dashboard-card">
		<h2>Loading streak data...</h2>
	</article>
{:else}
	<article class="dashboard-card">
		<h2>{error}</h2>
	</article>
{/if}

<style>
	article {
		display: flex;
		flex-direction: column;
		align-items: center;
		background-color: #fff;
		border-radius: 5px;
		box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2);
		padding: 1rem;
		margin: 0.75rem;
		transition: 0.3s;
	}

	article:hover {
		background-color: #d1ccff;
		box-shadow: 0 8px 16px 0 rgba(0, 0, 0, 0.2);
	}

	p,
	h2 {
		color: black;
		padding-bottom: 1rem;
	}
</style>