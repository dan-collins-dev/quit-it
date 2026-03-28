<script>
	import { onMount } from "svelte";
	import cigIconSrc from "$lib/assets/cigarette-svgrepo-com.svg";

	let loaded = $state(null);
	let error = $state(null);
	let data = $state([]);
	let lastLog = $derived(data[data.length - 1]);

	let date = $derived.by(() => {
		if (isSameUTCDay(lastLog?.date)) {
			const lastDate = new Date(lastLog?.date);
			return lastDate.toDateString();
		} else {
			return new Date().toDateString();
		}
	});

	let count = $derived.by(() => {
		if (isSameUTCDay(lastLog?.date)) {
			return lastLog?.numOfCigs;
		} else {
			return false;
		}
	});

    function isSameUTCDay(lastLogDate) {
		const today = new Date();
		const lastDate = new Date(lastLogDate);

		return (
			today.getUTCFullYear() === lastDate.getUTCFullYear() &&
			today.getUTCMonth() === lastDate.getUTCMonth() &&
			today.getUTCDate() === lastDate.getUTCDate()
		);
	}

	async function getLogs() {
		try {
			const res = await fetch("http://localhost:5150/api/logs");
			const data = await res.json();
			return data;
		} catch (error) {
			console.error(error);
		}
	}

	onMount(async () => {
		try {
			data = await getLogs();
			loaded = true;
		} catch (err) {
			error = err.message;
		}
	});
</script>

{#if loaded}
	<article class="dashboard-card">
		<h2>{date}</h2>
		<div class="logo-container">
			<img class="cig-logo" src={cigIconSrc} alt="" />
		</div>
		<p class="card-category">Cigarettes Smoked Today</p>
		<p class="card-number">{count || 0}</p>
	</article>
{:else if !loaded}
	<article class="dashboard-card">
		<h2>Loading Count Data...</h2>
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

	h2 {
		color: black;
		padding-bottom: 1rem;
	}
</style>
