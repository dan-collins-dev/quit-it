<script>
	import DashboardCard from '$lib/components/DashboardCard.svelte';
	import cigIconSrc from '$lib/assets/cigarette-svgrepo-com.svg';
	import cashIconSrc from '$lib/assets/cash-outline.svg';
	import graveIconSrc from '$lib/assets/grave-illustration-3-svgrepo-com.svg';
    // let {data} = $props();
	
</script>

<section class="card-container">
    <!-- {#each data.logs as log (log.id)}
        <DashboardCard data={log} count={log.numOfCigs} />
    {/each} -->
	
	<DashboardCard iconSrc={cigIconSrc} label="Cigarettes Smoked Today" count="23" />
	<DashboardCard iconSrc={cashIconSrc} label="Cigarettes Smoked Today" count="$10000.23" />
	<DashboardCard iconSrc={graveIconSrc} label="Cigarettes Smoked Today" count="00:00:00" />
	<DashboardCard iconSrc={cigIconSrc} label="Cigarettes Smoked Today" count="23" />
	<DashboardCard iconSrc={cigIconSrc} label="Cigarettes Smoked Today" count="23" />

</section>

<style>
	.card-container {
		display: grid;
		grid-template-columns: 1fr;
	}
</style>
